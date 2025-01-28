namespace InternIntelligence_Portfolio.Dtos
{
    public class AchievementDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Created { get; set; } = DateTime.Now;
        public string? CertificateUrl { get; set; }
    }
}
