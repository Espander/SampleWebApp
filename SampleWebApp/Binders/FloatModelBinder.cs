using System;
using System.Globalization;
using System.Web.Mvc;

namespace SampleWebApp.Binders
{

    public class FloatModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            float result;
            if (float.TryParse(valueProviderResult?.AttemptedValue, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                return result;
            }
            return base.BindModel(controllerContext, bindingContext);

        }
    }


}