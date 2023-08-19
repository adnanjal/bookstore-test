import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { BookService } from '../../services/book.service';
import { BookQuery } from '../../queries/book.query';
import { Book } from '../../models/book.model';

@Component({
  selector: 'book-list',
  template: `../book-listing.component.html`,
})
export class TodoComponent {
  books$: Observable<Book[]> = this.todoQuery.selectAll();

  constructor(private bookService: BookService, private todoQuery: BookQuery) {}

  // Example method to add a book
  addBook() {
    const book: Book = {
      id: -1,
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
