import { AddressModel } from "./address.model";

export interface TeacherModel{
    id: number;
    firstName: string;
    lastName: string;
    profession: string;
    email: string;
    gender: number;
    score: number;
    numberOfOpinions: number;
    address: AddressModel
}

export interface TeacherRequestModel{
    firstName: string;
    lastName: string;
    profession: string;
    email: string;
    gender: number;
    score: number;
    numberOfOpinions: number;
    address: AddressModel;
}