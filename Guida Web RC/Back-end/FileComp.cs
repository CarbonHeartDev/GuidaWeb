using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Upload.Immagine
{
    public static class FileComp
    {
    /*Le seguenti due funzioni controllano le estensioni degli eventuali file immagine e audio che si vogliono inserire in una nuova scheda per accertarsi che siano
     di formati supportati.*/
        public static bool picComp(String name)
        {
            if((name.ToLower()).EndsWith(".bmp")|| (name.ToLower()).EndsWith(".jpeg")|| (name.ToLower()).EndsWith(".jpg")|| (name.ToLower()).EndsWith(".gif") || (name.ToLower()).EndsWith(".png")){
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool audioComp(String name)
        {
            if (name.EndsWith(".mp3")){
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}