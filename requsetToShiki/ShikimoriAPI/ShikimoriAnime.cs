﻿namespace RequestToShiki.ShikimoriAPI;
internal class ShikimoriAnime
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Russian { get; set; }
    public string Description { get; set; }
    public string[] English { get; set; }
    public string[] Japanese { get; set; }
}
