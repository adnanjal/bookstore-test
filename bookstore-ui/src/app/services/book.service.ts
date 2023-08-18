import { Injectable } from '@angular/core';
import { Book } from '../models/book.model';
import { BookStore } from '../stores/book.store';

@Injectable({ providedIn: 'root' })
export class BookService {
  constructor(private bookStore: BookStore) { }

  // Example method to add a book
  add(book: Book) {
    this.bookStore.add(book);
  }

  // Other methods like Get, GetAll, Delete, or Edit...
}
