export interface AuthenticationResponse {
  personName: string | null;
  email: string | null;
  token: string | null;
  expiration: string;
}
