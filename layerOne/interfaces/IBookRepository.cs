using layerOne.models;

namespace layerOne.interfaces
{
    public interface IBookRepository: IRepository<Book>
    {
        //списание книги, но сути обновление информации, в котором присваивается дата списания
        Task TakeOff(Book book);
    }
}
