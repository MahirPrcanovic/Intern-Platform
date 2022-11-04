// export interface Application {
//   Id: number;
//   FirstName: string;
//   LastName: string;
//   Email: string;
//   EducationLevel: string;
//   CoverLetter: string;
//   CV: string;
//   Status: string;
// }
export class Application {
  constructor(
    public Id: number,
    public firstName: string,
    public lastName: string,
    public Email: string,
    public EducationLevel: string,
    public CoverLetter: string,
    public CV: string,
    public Status: string
  ) {}
}
