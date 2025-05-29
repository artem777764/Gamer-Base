import type { IComment } from "@/types/comment"

export interface IReview {
    ReviewId: number
    UserName: string
    UserImageURL: string
    Mark: number
    Title: string
    Content: string
    Date: Date
    Rating: number
    Comments: IComment[]
}