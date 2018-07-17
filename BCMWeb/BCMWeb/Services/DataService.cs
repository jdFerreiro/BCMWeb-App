using BCMWeb.Interfaces;
using BCMWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BCMWeb.Services
{
    public static class DataService
    {
        private static string baseUrl = "https://www.bcmweb.net/";
        private static CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();
        private static CancellationToken _cancelToken = _cancelTokenSource.Token;

        public static async Task<TokenModel> GetToken(string userName, String userPasw)
        {
            TokenModel _token = new TokenModel();

            using (HttpClient _httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var param = new Dictionary<string, string>
                {
                    {"grant_type", "password" },
                    {"username", userName },
                    {"password", userPasw },
                };

                string _url = baseUrl + "token";
                var request = new HttpRequestMessage(new HttpMethod("POST"), _url)
                {
                    Content = new FormUrlEncodedContent(param),
                };

                try
                {
                    _httpClient.Timeout = TimeSpan.FromMinutes(30);
                    var _result = await _httpClient.SendAsync(request, _cancelToken).ConfigureAwait(false);
                    if (_result.IsSuccessStatusCode)
                    {
                        string _resultContent = await _result.Content.ReadAsStringAsync().ConfigureAwait(false);
                        _token = JsonConvert.DeserializeObject<TokenModel>(_resultContent);
                    }
                    else
                    {
                        _token.ErrorMessage = "Credenciales inválidas";
                    }
                }
                catch (TaskCanceledException tex)
                {
                    _token.ErrorMessage = tex.Message;
                }
                catch (Exception ex)
                {
                    _token.ErrorMessage = ex.Message;
                }
            }

            return _token;
        }
        public static async Task<UsuarioModel> GetDataUsuario(string _query, string _token)
        {
            UsuarioModel _usuario = new UsuarioModel();

            try
            {
                using (HttpClient _httpClient = new HttpClient())
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                    _httpClient.Timeout = TimeSpan.FromMinutes(30);
                    string _url = baseUrl + _query;
                    HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("GET"), _url);
                    var result = await _httpClient.SendAsync(request, _cancelToken).ConfigureAwait(false);
                    if (result.IsSuccessStatusCode)
                    {
                        string json = result.Content.ReadAsStringAsync().Result;
                        _usuario = JsonConvert.DeserializeObject<UsuarioModel>(json);
                        _usuario.ErrorMessage = string.Empty;

                        long _IdUsuario = _usuario.Id;
                        string _IpAddresss = DependencyService.Get<IIPAddressManager>().GetIpAddress();

                        AuditoriaModel _regAud = new AuditoriaModel
                        {
                            Accion = string.Format("Accesa {0} vía móvil", _usuario.Nombre),
                            ErrorMessage = string.Empty,
                            IdUsuario = _IdUsuario,
                            IpAddress = _IpAddresss,
                            Mensaje = String.Empty,
                            Negocios = true,
                        };
                        string _serData = JsonConvert.SerializeObject(_regAud);
                        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        _url = baseUrl + "api/auditoria/add";
                        request = new HttpRequestMessage(new HttpMethod("POST"), _url)
                        {
                            Content = new StringContent(_serData, Encoding.UTF8, "application/json")
                        };
                        result = await _httpClient.SendAsync(request, _cancelToken).ConfigureAwait(false);

                        /* Dispositivos */

                        DispositivoModel Dispositivo = DependencyService.Get<IIDeviceManager>().GetDeviceData();
                        Dispositivo.FechaRegistro = DateTime.Now;
                        Dispositivo.IdUsuario = _IdUsuario;

                        _url = baseUrl + "api/device/existDevice/" + Dispositivo.IdUnicoDispositivo;
                        request = new HttpRequestMessage(new HttpMethod("GET"), _url);
                        result = await _httpClient.SendAsync(request, _cancelToken).ConfigureAwait(false);
                        if (result.IsSuccessStatusCode)
                        {
                            json = result.Content.ReadAsStringAsync().Result;
                            long dispId = JsonConvert.DeserializeObject<long>(json);

                            if (dispId == 0)
                            {
                                string serDataDisp = JsonConvert.SerializeObject(Dispositivo);
                                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                _url = baseUrl + "api/device/adddevice";

                                request = new HttpRequestMessage(new HttpMethod("POST"), _url)
                                {
                                    Content = new StringContent(serDataDisp, Encoding.UTF8, "application/json")
                                };
                                result = await _httpClient.SendAsync(request, _cancelToken).ConfigureAwait(false);
                                if (result.IsSuccessStatusCode)
                                {
                                    json = result.Content.ReadAsStringAsync().Result;
                                    Dispositivo = JsonConvert.DeserializeObject<DispositivoModel>(json);
                                    dispId = Dispositivo.Id;
                                }
                            }
                            _usuario.IdDispositivo = dispId;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                _usuario.ErrorMessage = ex.Message;
            }

            return _usuario;
        }

    }
}
