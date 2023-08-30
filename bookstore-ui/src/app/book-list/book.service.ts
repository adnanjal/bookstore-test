import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Book } from './book.model';
import { BookStore } from './book.store';
import { HttpClient } from '@angular/common/http';
import { tap, catchError, throwError } from 'rxjs';


@Injectable({ providedIn: 'root' })
export class BookService {
  constructor(private bookStore: BookStore, private http: HttpClient) { }

  // Example method to add a book
  add(book: Book) {
    this.bookStore.add(book);
  }

  fetchBooksViaApi(page: number = 0){
    this.http.get<Book[]>(environment.apiURL + 'Book/ByPage?page=' + page)
  .pipe(
    tap(books => {
      console.log(books);
      this.bookStore.set(books);
    }),
    catchError(error => {
      console.error('Error fetching books:', error);
      return throwError(() => new Error('Error Fetching Books'));
    })
  )
  .subscribe();
  }

  fetchBooks(page: number = 0) {
    var data: any;

    var book1: Book = {
      id: 1,
      Title: "T1",
      Description: "Desc1"
    };
  var book2: Book = {
      id: 2,
      Title: "T2",
      Description: "Desc2"
    };
  var book3: Book = {
      id: 3,
      Title: "T3",
      Description: "Desc3"
    };
  var book4: Book = {
      id: 4,
      Title: "T4",
      Description: "Desc4"
    };
  var book5: Book = {
      id: 5,
      Title: "T4",
      Description: "Desc4"
    };

  data.add(book1);
  data.add(book2);
  data.add(book3);
  data.add(book4);
  data.add(book5);

  console.log(data);

  this.bookStore.add(data);

    // this.http.get(environment.apiURL + '/Book/ByPage?' + 'page=' + page).subscribe((data: any) => {
    //   if(data){

    //     //load sample data

    //   }
    // });
  }
  // Other methods like Get, Delete, or Edit...
}
