import { Component, Output, Input, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-primary-button',
  templateUrl: '../primary-button.component.html',
  styleUrls: ['../primary-button.component.css'],
})
export class PrimaryButtonComponent {
  @Input() label: string;
  @Output() onClick = new EventEmitter<void>();

  constructor(label: string, onclick: EventEmitter<void>) {
    this.label = label;
    this.onClick = onclick;
  }
}
