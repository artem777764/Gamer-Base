export interface IGame {
  Id: number
  Name: string
  Description: string
  Genres: [string]
  Developer: string
  Publisher: string
  ImageURL: string
  Platforms: [string]
  ReleaseDate: Date
  Rating: number | null
}