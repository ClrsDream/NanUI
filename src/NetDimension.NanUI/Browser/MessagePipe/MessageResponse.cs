namespace NetDimension.NanUI.Browser.MessagePipe;

public class MessageResponse
{
    public bool IsSuccess { get; set; } = true;
    public string Result { get; set; }
    public string Data { get; set; }
    public MessageResponse(bool isSuccess, string exception)
    {
        IsSuccess = isSuccess;
        Result = exception;
    }

    public MessageResponse()
    {
        IsSuccess = true;
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

    internal static MessageResponse FromJson(string json)
    {
        return JsonConvert.DeserializeObject<MessageResponse>(json);
    }
}
