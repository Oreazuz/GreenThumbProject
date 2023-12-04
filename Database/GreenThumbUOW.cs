﻿namespace GreenThumbProject.Database
{
    public class GreenThumbUOW
    {
        private readonly AppDbContext context;
        public UserRepository UserRepository { get; }
        public PlantRepository PlantRepository { get; }
        public GreenThumbUOW(AppDbContext context)
        {
            this.context = context;
            UserRepository = new(context);
            PlantRepository = new(context);
        }

        public async Task Complete()
        {
            await context.SaveChangesAsync();
        }
    }
}
