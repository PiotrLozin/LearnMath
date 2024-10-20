import { AddressModel } from "./address.model";

export interface TeacherModel{
    id: number;
    firstName: string;
    lastName: string;
    profession: string;
    email: string;
    gender: string;
    address: AddressModel
}

export interface TeacherPostRequestModel{
    firstName: string;
    lastName: string;
    profession: string;
    email: string;
    gender: number;
    address: AddressModel;
}

export interface TeacherEditRequestModel{
    firstName: string;
    lastName: string;
    profession: string;
    email: string;
    gender: number;
    addressForm: AddressModel;
}