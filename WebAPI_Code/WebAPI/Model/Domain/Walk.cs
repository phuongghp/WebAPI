﻿namespace WebAPI.Model.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }  
        public Guid RegionIdP { get; set; }
        public Guid WalkDifficultyId { get; set; }

        //navigation
        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
