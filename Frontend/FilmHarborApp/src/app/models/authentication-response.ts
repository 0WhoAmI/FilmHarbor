export interface AuthenticationResponse {
  id: number;
  personName: string | null;
  email: string | null;
  token: string | null;
  expiration: string;
}
