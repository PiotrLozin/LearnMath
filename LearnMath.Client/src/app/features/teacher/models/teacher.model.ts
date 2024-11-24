import { AddressModel } from "./address.model";

export interface TeacherModel{
    id: number;
    firstName: string;
    lastName: string;
    subjects: [];
    email: string;
    gender: string;
    address: AddressModel;
    totalOpinions: number
}

export interface TeacherPostRequestModel{
    firstName: string;
    lastName: string;
    subjects: [];
    email: string;
    gender: number;
    address: AddressModel;
}

export interface TeacherEditRequestModel{
    firstName: string;
    lastName: string;
    email: string;
    gender: number;
    addressForm: AddressModel;
}