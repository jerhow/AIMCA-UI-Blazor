namespace MedicalCodingAssistant.UI.Models;

public class ICD10SearchResponse
{
    public bool UsedFreeTextFallback { get; set; }
    public int TotalSqlResultCount { get; set; }
    public List<ICD10SearchResult> SearchResults { get; set; } = new();
}

public class ICD10SearchResult
{
    public string code { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public int rank { get; set; }
    public string reason { get; set; } = string.Empty;
    public string source { get; set; } = string.Empty;
    public int confidence { get; set; }
    public bool IsValid { get; set; }
}
