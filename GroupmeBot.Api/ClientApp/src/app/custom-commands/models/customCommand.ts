interface CustomCommand {
  mongoId?: string;
  commandPrompt: string;
  commandResponse: string;

  editing: boolean;
}
