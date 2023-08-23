import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { BookQuery } from './book.query';
import { Book } from './book.model';
import { BookService } from './book.service';

@Component({
  selector: 'book-list',
  template: `./book-listing.component.html`,
})
export class BookListComponent {
  books$: Observable<Book[]> = this.todoQuery.selectAll();

  constructor(private bookService: BookService, private todoQuery: BookQuery) {}

  // Example method to add a book
  addBook() {
    const book: Book = {
      id: 1,
      title: 'New Book Title',
      description: 'New Description',
    };
    this.bookService.add(book);
  }

  // ...other methods
  ngOnInit() {
    this.bookService.fetchBooks();
  }

  refreshBooks() {
    this.bookService.fetchBooks();
  }
}
