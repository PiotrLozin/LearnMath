import { AddressModel } from "./address.model";

export interface TeacherModel{
    id: number;
    firstName: string;
    lastName: string;
    profession: string;
    email: string;
    gender: boolean;
    score: number;
    numberOfOpinions: number;
    address: AddressModel
}