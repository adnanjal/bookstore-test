import { EntityState, EntityStore, StoreConfig } from '@datorama/akita';
import { Book } from '../models/book.model';

export interface BookState extends EntityState<Book> { }

@StoreConfig({ name: 'books' })
export class BookStore extends EntityStore<BookState> {
  constructor() {
    super();
  }
}
