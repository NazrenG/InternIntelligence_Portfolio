namespace InternIntelligence_Portfolio.Dtos
{
    public class AddProjectDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }= DateTime.Now; 
    }
}
