import { TeacherModel } from "../../teacher/models/teacher.model"

export interface GetTeacherOpinionsResponseModel{
    userOpinions: UserOpinionModel[]
}

export interface UserOpinionModel{
    score: number,
    description: string,
    createdByUser: string,
    teacher: TeacherModel
}

export interface UserOpinionPostRequestModel{
    score: number,
    description: string,
    creatorId: number,
    teacherId: number
}