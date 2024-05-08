export type ObjectId = {
  id: string;
};

export type Message = {
  title: string;
  details?: string;
};

export type ProblemDetails = {
  title: string;
  status: number;
  detail?: string;
};

export type Paged<T> = {
  page: number;
  items: T[];
  hasNext: boolean;
  hasPrevious: boolean;
};
