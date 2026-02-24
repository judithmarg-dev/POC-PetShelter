import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from '../environments/environment';
import {
  AttendantModel,
  AdoptantModel,
  PetModel,
  PetCardsListItemModel,
  CreatePetCardModel
} from './models';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class ApiService {
  private readonly base = environment.apiBaseUrl;

  constructor(private http: HttpClient) {}

  getAttendants(): Observable<AttendantModel[]> {
    return this.http
      .get<AttendantModel[]>(`${this.base}/api/Attendant`)
      .pipe(catchError(this.handleError));
  }

  getAdoptants(): Observable<AdoptantModel[]> {
    return this.http
      .get<AdoptantModel[]>(`${this.base}/api/Adoptant`)
      .pipe(catchError(this.handleError));
  }

  getPets(): Observable<PetModel[]> {
    return this.http
      .get<PetModel[]>(`${this.base}/api/Pet`)
      .pipe(catchError(this.handleError));
  }

  getPetCards(): Observable<PetCardsListItemModel[]> {
    return this.http
      .get<PetCardsListItemModel[]>(`${this.base}/api/PetCard`)
      .pipe(catchError(this.handleError));
  }

  createPetCard(body: CreatePetCardModel): Observable<void> {
    return this.http
      .post<void>(`${this.base}/api/PetCard`, body)
      .pipe(catchError(this.handleError));
  }

  private handleError(err: HttpErrorResponse) {
    console.error('[API ERROR]', err);
    return throwError(() => err);
  }
}