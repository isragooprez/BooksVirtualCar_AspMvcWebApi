using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//IModelBinder
using System.Web.Mvc;

namespace VirtualCar.Models.ModelsBinder
{
    public class VirtualCarModelBinder : IModelBinder
    {
        //Variable de session
        private string token_session_virtual_car = "token_session_virtual_car";

        public object BindModel(ControllerContext cctx, ModelBindingContext mbctc)
        {
            VirtualCarModels _virtualCar = (VirtualCarModels)cctx.HttpContext.Session[token_session_virtual_car];
            if (_virtualCar == null)
            {
                _virtualCar = new VirtualCarModels();
                cctx.HttpContext.Session[token_session_virtual_car] = _virtualCar;
            }
            return _virtualCar;
        }
    }
}