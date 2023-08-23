import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Book } from './book.model';
import { BookStore } from './book.store';
import { HttpClient } from '@angular/common/http';


@Injectable({ providedIn: 'root' })
export class BookService {
  constructor(private bookStore: BookStore, private http: HttpClient) { }

  // Example method to add a book
  add(book: Book) {
    this.bookStore.add(book);
  }

  fetchBooks(page: number = 0) {
    this.http.get(environment.apiURL + '/Book/ByPage?' + 'page=' + page).subscribe((data: any) => {
      this.bookStore.set(data);
    });
  }
  // Other methods like Get, Delete, or Edit...
}
