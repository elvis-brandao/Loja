import { useEffect, useState } from "react";
import {
  obterProdutos,
  criarProduto,
  atualizarProduto,
  excluirProduto
} from "../services/produtoService";
import type { Produto } from "../types/Produto";

export function useProdutos() {

  const [produtos, setProdutos] =
    useState<Produto[]>([]);

  const [produtoSelecionado,
    setProdutoSelecionado] =
    useState<Produto | null>(null);

  useEffect(() => {
    carregarProdutos();
  }, []);

  async function carregarProdutos() {
    const resultado =
        await obterProdutos();

    setProdutos(resultado.data);
  }

  async function salvarProduto(
    nome: string,
    preco: number
  ) {
      await criarProduto(
      nome,
      preco
    );

    await carregarProdutos();
  }
  
  async function editarProduto(
    id: number,
    nome: string,
    preco: number
  ) {
      await atualizarProduto(
        id,
        nome,
        preco
      );

    setProdutoSelecionado(null);

    await carregarProdutos();
  }

  async function removerProduto(
    id: number
  ) {
      const confirmar =
        window.confirm(
          "Deseja excluir este produto?"
        );

      if (!confirmar) {
        return;
      }

      await excluirProduto(id);

      await carregarProdutos();
  }

  return {
    produtos,
    produtoSelecionado,
    setProdutoSelecionado,

    salvarProduto,
    editarProduto,
    removerProduto
  };
}