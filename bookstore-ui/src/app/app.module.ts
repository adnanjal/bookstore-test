import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';

import { environment } from './environments/environment';
import { AkitaNgDevtools } from '@datorama/akita-ngdevtools';
import { BookListComponent } from './book-list/book-list.component';
import { BookService } from './book-list/book.service';
import { BookQuery } from './book-list/book.query';
import { BookStore } from './book-list/book.store';

@NgModule({
  declarations: [
    AppComponent,
    BookListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    environment.production ? [] : AkitaNgDevtools?.forRoot(),
  ],
  providers: [BookStore, BookService, BookQuery],
  bootstrap: [AppComponent]
})
export class AppModule { }
