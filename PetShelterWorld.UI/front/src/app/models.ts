
export interface AttendantModel {
  id: number;
  name: string;
}

export interface AdoptantModel {
  id: number;
  name: string;
  hasPets: boolean;
}


export interface PetModel {
  id: number;
  name: string;
  age: number;
  type: string;
}

export interface PetCardsListItemModel {
  id: number;
  dateAdoption: string;
  adoptantName: string;
  attendantName: string;
  petName: string;
  requirements: string;
  daysOnShelter: number;
}

export interface CreatePetCardModel {
  id?: string;          
  adoptantId: number;
  attendantId: number;
  petId: number;
  requirement: string;
  daysOnShelter: number;
}
