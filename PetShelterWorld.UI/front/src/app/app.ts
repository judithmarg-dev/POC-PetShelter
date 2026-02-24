import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ShelterComponent } from './shelter/shelter.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ShelterComponent],
  template: `<app-shelter />`,
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('front');
}
