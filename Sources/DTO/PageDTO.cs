namespace DTO;

/// <summary>
/// Classe correspondant à un Page, elle sert à transférer des données entre l'API et l'application cliente
/// Elle permet de limiter les données échangées en ne renvoyant que les informations utiles au client
/// </summary>
public class PageDTO<T>
{
    public T Data { get; set; }
    public int Index { get; set; }
    public int Count { get; set; }
    public int TotalCount { get; set; }
}