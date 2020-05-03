import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Library {
    @JsonProperty("books")
    private List<Book> bookList = new ArrayList<Book>();

    public Library(List<Book> bookList) {
        this.bookList = bookList;
    }

    public Library() {
    }

    public List<Book> getBookList() {
        return bookList;
    }

    public void setBookList(List<Book> bookList) {
        this.bookList = bookList;
    }

    @Override
    public String toString() {
        return "Library{" +
                "bookList=" + bookList +
                '}';
    }

    public void groupByAuthor() {
        this.bookList.stream().collect(Collectors.groupingBy(Book::getAuthor)).forEach((author, books) -> {
            System.out.println("author: " + author);
            books.forEach((book -> System.out.println("book: " + book.getTitle())));
            System.out.println();
        });

    }
}
