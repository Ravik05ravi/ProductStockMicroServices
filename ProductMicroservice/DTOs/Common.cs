using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.DTOs
{
    public class Common
    {
    }

    public record ErrorResponse(string Response, int code, string Description)
    {
        public override string ToString() =>  $"{{Reason:{Response},Code:{code},Description:{Description}}}";

    }
    public enum ErrorReason
    {
        success, created, noContent, notAllowed, validationFail, internalError, unsupportedMediaType, unauthorized, networkError, invalidDateRange, existingTisService, invalidDefinitionId, timeout
    }

    public class RequestIncreaseorDecreaseStockquantity
    {
        public int Productid { get; set; }
        public int Quantity { get; set; }
    }

}
