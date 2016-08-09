using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Shop
{
    public class cOdeme
    {
        public class AdresBilgileri
        {
            private string ad;
            private string soyad;
            private string cadde;
            private string sokak;
            private string mahalle;
            private int postaKodu;
            private string ıl;
            private string ılce;
            private string telefon;
            private string email;
            #region AdresProp
            public string Ad
            {
                get
                {
                    return ad;
                }

                set
                {
                    ad = value;
                }
            }

            public string Soyad
            {
                get
                {
                    return soyad;
                }

                set
                {
                    soyad = value;
                }
            }

            public string Cadde
            {
                get
                {
                    return cadde;
                }

                set
                {
                    cadde = value;
                }
            }

            public string Sokak
            {
                get
                {
                    return sokak;
                }

                set
                {
                    sokak = value;
                }
            }

            public string Mahalle
            {
                get
                {
                    return mahalle;
                }

                set
                {
                    mahalle = value;
                }
            }

            public int PostaKodu
            {
                get
                {
                    return postaKodu;
                }

                set
                {
                    postaKodu = value;
                }
            }

            public string Il
            {
                get
                {
                    return ıl;
                }

                set
                {
                    ıl = value;
                }
            }

            public string Ilce
            {
                get
                {
                    return ılce;
                }

                set
                {
                    ılce = value;
                }
            }

            public string Telefon
            {
                get
                {
                    return telefon;
                }

                set
                {
                    telefon = value;
                }
            }

            public string Email
            {
                get
                {
                    return email;
                }

                set
                {
                    email = value;
                }
            }

            #endregion

        }
        public class KargoBilgileri
        {
            private string Kargo;

            public string Kargo1
            {
                get
                {
                    return Kargo;
                }

                set
                {
                    Kargo = value;
                }
            }

            #region KargoProp

            #endregion
        }
        public class OdemeBilgileri
        {

            private bool OdemeTuru;
            private string KartAd;
            private string KartSoyad;
            private decimal KartNo;
            private int CvcNo;
            private DateTime SkTarihi;
            private int TaksitSayisi;
            private DateTime SiparisTrh;
            private DateTime TeslimTrh;
            #region OdemeProp
            public bool OdemeTuru1

            {
                get
                {
                    return OdemeTuru;
                }

                set
                {
                    OdemeTuru = value;
                }
            }

            public string KartAd1
            {
                get
                {
                    return KartAd;
                }

                set
                {
                    KartAd = value;
                }
            }

            public decimal  KartNo1
            {
                get
                {
                    return KartNo;
                }

                set
                {
                    KartNo = value;
                }
            }

            public int CvcNo1
            {
                get
                {
                    return CvcNo;
                }

                set
                {
                    CvcNo = value;
                }
            }

            public DateTime SkTarihi1
            {
                get
                {
                    return SkTarihi;
                }

                set
                {
                    SkTarihi = value;
                }
            }

            public int TaksitSayisi1
            {
                get
                {
                    return TaksitSayisi;
                }

                set
                {
                    TaksitSayisi = value;
                }
            }

            public string KartSoyad1
            {
                get
                {
                    return KartSoyad;
                }

                set
                {
                    KartSoyad = value;
                }
            }

            public DateTime SiparisTrh1
            {
                get
                {
                    return SiparisTrh;
                }

                set
                {
                    SiparisTrh = value;
                }
            }

            public DateTime TeslimTrh1
            {
                get
                {
                    return TeslimTrh;
                }

                set
                {
                    TeslimTrh = value;
                }
            }

            #endregion
        }
    }
}

