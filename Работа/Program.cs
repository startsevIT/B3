List<Request> requests = new List<Request>
{
    new Request(1,"2023-06-06","Компьютер","DEXP Aquilion O286","Перестал работать","Сорокин Дмитрий Ильич","89219567841","в процессе ремонта") { Master = "Ильин Александр Андреевич"},
};

var builder = WebApplication.CreateBuilder();
builder.Services.AddCors();
var app = builder.Build();
app.UseCors(x=>x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.MapGet("requests", () => requests);
app.MapGet("requests/{id}", (int id) => requests.Find(x => x.Id == id));
app.MapPost("requests", (CreateRequestDTO dto) => 
{ 
    Request request = new Request(dto.Id,dto.StartDate,dto.OrgTechType,dto.OrgTechModel,dto.ProblemDescription,dto.ClientFIO,dto.ClientNumber,dto.RequestStatus);
    requests.Add(request);
});
app.MapPut("requests/{id}", (int id,UpdateRequestDTO dto) =>
{
    Request request = requests.Find(x => x.Id == id);
    if (request != null)
    {
        if (dto.Master != "")
            request.Master = dto.Master;
        if (dto.ProblemDescription != "")
            request.Master = dto.Master;
        if (dto.RequestStatus != request.RequestStatus)
            request.Master = dto.Master;
        if (dto.RepairParts != "")
            request.RepairParts = dto.RepairParts;
        if (dto.Comment != "")
            request.Comment = dto.Comment;
    }
});
app.Run();

class CreateRequestDTO
{ 
    public int Id { get; set; }
    public string StartDate { get; set; }
    public string OrgTechType { get; set; }
    public string OrgTechModel { get; set; }
    public string ProblemDescription { get; set; }
    public string ClientFIO {  get; set; }
    public string ClientNumber { get; set; }
    public string RequestStatus { get; set; }
}
class UpdateRequestDTO
{
    public string Master {  get; set; }
    public string ProblemDescription { get; set; }
    public string RequestStatus { get; set; }
    public string Comment { get; set; }
    public string RepairParts { get; set; }
}
class Request
{
    public Request(int id, string startDate, string orgTechType, string orgTechModel, string problemDescription, string clientFIO, string clientNumber, string requestStatus)
    {
        Id = id;
        StartDate = startDate;
        OrgTechType = orgTechType;
        OrgTechModel = orgTechModel;
        ProblemDescription = problemDescription;
        ClientFIO = clientFIO;
        ClientNumber = clientNumber;
        RequestStatus = requestStatus;
    }

    public int Id { get; set; }
    public string StartDate { get; set; }
    public string OrgTechType { get; set; }
    public string OrgTechModel { get; set; }
    public string ProblemDescription { get; set; }
    public string ClientFIO { get; set; }
    public string ClientNumber { get; set; }
    public string RequestStatus { get; set; }
    public string Master { get; set; }
    public string Comment { get; set; }
    public string RepairParts { get; set; }
}
