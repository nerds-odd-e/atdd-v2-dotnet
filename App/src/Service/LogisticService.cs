using System.Text.Json;

namespace atdd_v2_dotnet.Service;

public class LogisticService
{
    private readonly HttpClient httpClient = new();

    public object queryOrderLogistics(string deliverNumber)
    {
        var logisticsResult = JsonSerializer.Deserialize<Logistics>(httpClient.GetStringAsync(
            "http://mock-server.tool.net:1080/express/query?type=auto&appkey=test&number=" +
            deliverNumber).Result)!.result;
        return new
        {
            DeliverNo = logisticsResult.number,
            CompanyCode = logisticsResult.type,
            CompanyName = logisticsResult.typename,
            CompanyLogo = logisticsResult.logo,
            Details = logisticsResult.list,
            DeliveryStatus = logisticsResult.deliverystatus == 1 ? "在途中" : "",
            IsSigned = logisticsResult.issign == 0 ? "未签收" : ""
        };
    }

    public class Logistics
    {
        public string msg { get; set; }
        public LogisticsResult result { get; set; }
        public int status { get; set; }

        public class LogisticsResult
        {
            public int deliverystatus { get; set; }
            public int issign { get; set; }
            public List<Detail> list { get; set; }
            public string number { get; set; }
            public string type { get; set; }
            public string typename { get; set; }
            public string logo { get; set; }
        }

        public class Detail
        {
            public string time { get; set; }
            public string status { get; set; }
        }
    }
}