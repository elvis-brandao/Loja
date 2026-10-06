import { useEffect, useState } from "react";

type ProdutoFormProps = {
  produtoSelecionado?: {
    id: number;
    nome: string;
    preco: number;
  } | null;

  onSalvar: (
    nome: string,
    preco: number
  ) => Promise<void>;

  onAtualizar: (
    id: number,
    nome: string,
    preco: number
  ) => Promise<void>;
};

export function ProdutoForm({ produtoSelecionado, onSalvar, onAtualizar }: ProdutoFormProps) {
  const [nome, setNome] = useState("");
  const [preco, setPreco] = useState("");

  useEffect(() => {
    if (produtoSelecionado) {
      setNome(produtoSelecionado.nome);
      setPreco(
        produtoSelecionado.preco.toString()
      );
    }
  }, [produtoSelecionado]);

  async function handleSubmit() {
    if (produtoSelecionado) {
      await onAtualizar(
        produtoSelecionado.id,
        nome,
        Number(preco)
      );
    } else {
      await onSalvar(
        nome,
        Number(preco)
      );
    }

    setNome("");
    setPreco("");
  }

  return (
    <div>
      <label>Nome</label>

      <br />

      <input
        value={nome}
        onChange={(e) =>
          setNome(e.target.value)}
      />

      <br />
      <br />

      <label>Preço</label>

      <br />

      <input
        type="number"
        value={preco}
        onChange={(e) =>
          setPreco(e.target.value)}
      />

      <br />
      <br />

      <button onClick={handleSubmit}>
        {produtoSelecionado
          ? "Atualizar"
          : "Salvar"}
      </button>
    </div>
  );
}