import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-get-teachers-filter',
  templateUrl: './get-teachers-filter.component.html',
  styleUrls: ['./get-teachers-filter.component.scss']
})
export class GetTeachersFilterComponent {
  @Output() filtersApplied = new EventEmitter<any>();

  filterForm: FormGroup;
  subjects = [
    { value: '0', label: 'Mathematics' },
    { value: '1', label: 'English' },
    { value: '2', label: 'Biology' },
    { value: '3', label: 'Chemistry' },
    { value: '4', label: 'Physics' },
    { value: '5', label: 'Informatics' },
  ];

  constructor(private fb: FormBuilder) {
    this.filterForm = this.fb.group({
      subject: [''],
      city: [''],
      score: [null],
      distance: [null],
      postalCode: [''],
    });
  }

  applyFilter() {
    const filters = this.filterForm.value;

    // Walidacja zależności między polami
    if (filters.postalCode && !filters.city) {
      alert('Kod pocztowy wymaga podania miasta.');
      return;
    }

    this.filtersApplied.emit(filters);
  }
}
