import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import {
  PetCardsListItemModel,
  CreatePetCardModel,
  AttendantModel,
  AdoptantModel,
  PetModel
} from '../models';
import { Observable } from 'rxjs';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-shelter',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './shelter.component.html',
  styleUrl: './shelter.component.css'
})
export class ShelterComponent {
  petCards$!: Observable<PetCardsListItemModel[]>;
  attendants$!: Observable<AttendantModel[]>;
  adoptants$!: Observable<AdoptantModel[]>;
  pets$!: Observable<PetModel[]>;
  form: FormGroup;

  constructor(private api: ApiService, private fb: FormBuilder) {
    this.form = this.fb.group({
      adoptantId: [null as number | null],
      attendantId: [null as number | null],
      petId: [null as number | null],
      requirement: [''],
      daysOnShelter: [0]
    });
  }

  submitting = false;
  errorMsg = '';


  ngOnInit(): void {
    this.loadAll();
  }

  loadAll() {
    this.petCards$ = this.api.getPetCards();
    this.attendants$ = this.api.getAttendants();
    this.adoptants$ = this.api.getAdoptants();
    this.pets$ = this.api.getPets();
  }

  submit() {
    this.errorMsg = '';
    if (this.form.invalid) return;

    const payload: CreatePetCardModel = {
      adoptantId: this.form.value.adoptantId!,
      attendantId: this.form.value.attendantId!,
      petId: this.form.value.petId!,
      requirement: this.form.value.requirement ?? '',
      daysOnShelter: this.form.value.daysOnShelter ?? 0
    };

    this.submitting = true;
    this.api.createPetCard(payload).subscribe({
      next: () => {
        this.submitting = false;
        this.form.reset({ daysOnShelter: 0 });
        this.loadAll();
      },
      error: (err) => {
        this.submitting = false;
        this.errorMsg = err?.error?.error ?? 'Error creating pet card';
      }
    });
  }
}