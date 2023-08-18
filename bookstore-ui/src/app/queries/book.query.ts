import { QueryEntity } from '@datorama/akita';
import { BookStore, BookState } from '../stores/book.store';
import { Book } from '../models/book.model';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class BookQuery extends QueryEntity<BookState, Book> {
  constructor(protected override store: BookStore) {
    super(store);
  }
}
