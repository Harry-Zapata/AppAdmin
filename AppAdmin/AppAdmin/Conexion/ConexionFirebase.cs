using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace AppAdmin.Conexion
{ 
    public class ConexionFirebase
    {
        public static FirebaseClient 
            ClientFirebase = new FirebaseClient
            ("https://appadmin21-default-rtdb.firebaseio.com");
    }
}
