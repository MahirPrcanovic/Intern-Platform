export interface ApplicantComment {
  id: string;
  application: [];
  comment: {
    commentText: string;
    dateCreated: string;
    id: string;
  };
  user: {
    userName: string;
  };
}
