import { FullApplication } from "./FullApplication";

export interface FullSelection {
    id: string;
    name: string;
    startDate: Date;
    endDate: Date;
    description:string;
    comments: [];
    applications: FullApplication[];
  }