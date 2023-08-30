import { Component } from '@angular/core';
import { Book } from './book.model';
import { BookService } from './book.service';
import { BookQuery } from './book.query';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent {
  books$: Observable<Book[]> = this.bookQuery.selectAll();

  constructor(private bookService: BookService, private bookQuery: BookQuery) {}

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
    this.bookService.fetchBooksViaApi();
  }

  refreshBooks() {
    this.bookService.fetchBooksViaApi();
  }
}
