using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AccesoDato;
using Modelo;
using Nancy.Json;
using Newtonsoft.Json;

namespace LogicaNegocio
{
    public class lnCuentaAxie
    {

        adCuentaAxie adCuentaAxie;
        public lnCuentaAxie(AccesoDato.Conexion conexion)
        {
            adCuentaAxie = new adCuentaAxie(conexion);
        }


        public async Task<ICollection<CuentaAxie>> ObtenerTodos()
        {           
            return await adCuentaAxie.ObtenerTodos(); ;
        }
        public async Task<ICollection<CuentaAxie>> ObtenerTodos(string UsuarioID)
        {
            return await adCuentaAxie.ObtenerTodos(int.Parse(UsuarioID)); 
        }
        public async Task<ICollection<CuentaAxie>> ObtenerTodosConDetalle(string UsuarioID)
        {
            var cuentas = await adCuentaAxie.ObtenerTodos(int.Parse(UsuarioID));
            foreach (var item in cuentas)
            {
                var url = $"https://lunacia.skymavis.com/game-api/clients/"+item.RoninWallet.Replace("ronin:","0x")+ "/items/1";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return null;
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                CuentaResponse ArbolRecibidos = JsonConvert.DeserializeObject<CuentaResponse>(responseBody);
                                item.DetalleCuentaAxie = ObtenerRank(ArbolRecibidos, item);
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    return null;
                }
            }
            return cuentas;
        }

        private DetalleCuentaAxie ObtenerRank(CuentaResponse pCuentaResponse, CuentaAxie item) {
            var url = $"https://lunacia.skymavis.com/game-api/leaderboard?client_id=" + item.RoninWallet.Replace("ronin:", "0x") + "&offset=0&limit=0";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            RankResponse ArbolRecibidos = JsonConvert.DeserializeObject<RankResponse>(responseBody);
                           return ConvertirCuentaAxie(pCuentaResponse, ArbolRecibidos);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
            return null;
        }

        private DetalleCuentaAxie ConvertirCuentaAxie(CuentaResponse pCuentaResponse, RankResponse Rank)
        {
            var url = $"https://api.coingecko.com/api/v3/simple/price?ids=smooth-love-potion&vs_currencies=usd";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            var SLPSUDT = 0D;
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            CoinGeko ArbolRecibidos = JsonConvert.DeserializeObject<CoinGeko>(responseBody);
                            SLPSUDT = ArbolRecibidos.SmoothLovePotion.usd;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
            var itemRank = Rank.items.FirstOrDefault();
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            var difference = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - pCuentaResponse.blockchain_related.signature.timestamp;
            var resul = difference / (60 * 60 * 24) +1;
            var daysDifference = resul;
            var slpjueg = pCuentaResponse.total - pCuentaResponse.blockchain_related.balance;
            var aux =  itemRank.win_total + itemRank.lose_total;
            var winrate = (Convert.ToDecimal(itemRank.win_total) / Convert.ToDecimal(aux)) * 100M;
            TimeSpan tSpan = DateTime.Now.ToLocalTime() - dtDateTime.AddSeconds(pCuentaResponse.blockchain_related.signature.timestamp).ToLocalTime().AddDays(14);
            DetalleCuentaAxie detalleCuentaAxie = new DetalleCuentaAxie()
            {
                CantidadSLP = pCuentaResponse.total,
                SLPEnJuego = slpjueg??0,
                SLPEnRoninWallet = pCuentaResponse.blockchain_related.balance??0,
                Copas = itemRank.elo,
                WinRate = Convert.ToInt32(winrate),
                DiasParaReclamarSLP = tSpan.Days *(-1),
                FechaParaReclamarSLP = dtDateTime.AddSeconds(pCuentaResponse.blockchain_related.signature.timestamp).ToLocalTime().AddDays(14),
                PromedioSLPDiario = Convert.ToInt32(slpjueg/ daysDifference??0),
                Ranking = itemRank.rank,
                SLP_A_USDT = SLPSUDT * pCuentaResponse.total
            };

            return detalleCuentaAxie;        
        }

            public async Task<CuentaAxie> Obtener(int pId)
        {
            return await adCuentaAxie.Obtener(pId); ;
        }

        public async Task<CuentaAxie> Insertar(CuentaAxie pCuentaAxie)
        {
            return await adCuentaAxie.Insertar(pCuentaAxie); ;
        }

        public async Task<CuentaAxie> Modificar(CuentaAxie pCuentaAxie)
        {
            return await adCuentaAxie.Modificar(pCuentaAxie); ;
        }

        public async Task<bool> Eliminar(CuentaAxie pCuentaAxie)
        {
            return await adCuentaAxie.Eliminar(pCuentaAxie); ;
        }
    }
}
