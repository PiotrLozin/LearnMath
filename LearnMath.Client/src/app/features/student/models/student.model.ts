import { AddressModel } from "../../teacher/models/address.model";

export interface StudentModel{
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    gender: number;
    address: AddressModel;
}

export interface StudentPostRequestModel{
    firstName: string;
    lastName: string;
    email: string;
    gender: number;
    address: AddressModel;
}