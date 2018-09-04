using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

using System.Linq;


namespace testdbfirst.Authen
{
   
    public static class AuthorizeSetController 
    {
        public static bool setAuthorize(String scopes)
        {
            if (!string.IsNullOrEmpty(ConfigAzureADB2C.ScopeRead) && scopes != null
                    && scopes.Split(' ').Any(s => s.Equals(ConfigAzureADB2C.ScopeRead)))
                return true;
            else
                return false;
        }
    }
}
