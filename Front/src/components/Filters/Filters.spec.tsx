import { fireEvent, render, screen } from "@testing-library/react";
import { Filters } from "./Filters";

jest.mock("react-error-boundary", () => ({
  ErrorBoundary: ({ children }: { children: React.ReactNode }) => children,
}));

describe("Filters", () => {
  test("render component", () => {
    render(<Filters onSearch={() => {}} />);
    expect(screen.getByText("Search")).toBeInTheDocument();
  });

  test("calls onClick when search button is clicked", async () => {
    const onSearch = jest.fn();
    render(<Filters onSearch={onSearch} />);

    fireEvent.click(screen.getByText("Search"))

    expect(onSearch).toHaveBeenCalled();
  });
});
