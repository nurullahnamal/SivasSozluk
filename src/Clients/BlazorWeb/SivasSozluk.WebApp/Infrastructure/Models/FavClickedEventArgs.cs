﻿namespace SivasSozluk.WebApp.Infrastructure.Models
{
    public class FavClickedEventArgs : EventArgs
    {
        public Guid? EntryId { get; set; }

        public bool IsFaved { get; set; }
    }
}
