import {Component, inject, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {

  title = 'frontend';
  message: string | undefined;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    let message = 'Hello World';
    this.http.get('/api/hello').subscribe((data: any) => {
      this.message = data.message;
    });
  }
}
